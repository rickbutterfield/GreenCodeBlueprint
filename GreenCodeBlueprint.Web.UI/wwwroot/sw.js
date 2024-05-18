const version = 'dev';

const offlineFundamentals = [
    // '/app/logo.svg',
];

self.addEventListener('install', function (event) {
    event.waitUntil(
        caches
            .open(version + '_fundamentals')
            .then(function (cache) {
                return cache.addAll(offlineFundamentals);
            })
            .then(function () {
                return self.skipWaiting();
            })
    );
});

self.addEventListener('fetch', function (event) {
    const requestUrl = event.request.url;
    const isGetRequest = event.request.method === 'GET';

    const destination = event.request.destination;
    const isFont = destination === 'font';
    const isDocument = destination === 'document';
    const isImage = destination === 'image' || destination === '' && requestUrl.endsWith('.svg');
    const isVideo = requestUrl.endsWith('.mp4');
    const isScript = destination === 'script';
    const isStyle = destination === 'style';

    const regex = /^(https|http)(:\/\/)(([a-z0-9-])+(.))?([a-z].+)?(localhost:44345)(\/)(app\/assets|media)/g;
    const regexStaticAssets = /^(https|http)(:\/\/)(([a-z0-9-])+(.))?([a-z].+)?(localhost:44345)(\/)(app\/assets)/g;

    const isWhitelistedUrl = requestUrl.match(regex) !== null;
    const isStaticAsset = requestUrl.match(regexStaticAssets) !== null;

    if (isGetRequest && isWhitelistedUrl && !isDocument) {
        if (isScript || isStyle || isFont || (isImage && isStaticAsset)) {
            event.respondWith(
                caches.match(event.request).then(response => {
                    function fetchAndCache() {
                        return fetch(event.request).then(response => {
                            if (response.headers.get('Content-Length') !== '0') {
                                const cacheCopy = response.clone();
                                let cacheLocation = version;

                                if (isImage || isFont) {
                                    cacheLocation += '_staticAssets';
                                }

                                if (isScript || isStyle) {
                                    cacheLocation += '_scriptStyle';
                                }

                                caches.open(cacheLocation).then(cache => cache.put(event.request, cacheCopy));
                            }
                            return response;
                        });
                    }

                    if (!response) { return fetchAndCache(); }
                    return response;
                })
            );
        }

        if ((isImage || isVideo) && !isStaticAsset) {
            console.log(requestUrl);
            event.respondWith(
                caches.match(event.request).then(response => {
                    function fetchAndCache() {
                        return fetch(event.request).then(response => {
                            if (response.headers.get('Content-Length') !== '0') {
                                const cacheCopy = response.clone();
                                let cacheLocation = version;
                                cacheLocation += '_umbracoImages';

                                caches.open(cacheLocation).then(cache => cache.put(event.request, cacheCopy));
                            }
                            return response;
                        });
                    }

                    if (!response) { return fetchAndCache(); }
                    return response;
                })
            );
        }
    }
    else return;
});

self.addEventListener('activate', function (event) {
    event.waitUntil(
        caches
            .keys()
            .then(function (keys) {
                return Promise.all(
                    keys
                        .filter(function (key) {
                            return !key.startsWith(version);
                        })
                        .map(function (key) {
                            return caches.delete(key);
                        })
                );
            })
    );
});