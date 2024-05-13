import { defineConfig } from 'vite';
import { resolve } from 'path';
import { getAspDotNetCertificate } from './build/certs';

import tailwindcss from "tailwindcss";
import autoprefixer from "autoprefixer";

export default defineConfig(async ({ mode }) => {
    console.log(`Configuring Vite for ${mode} mode.`);

    const config = {
        appType: 'custom',
        css: {
            devSourcemap: true,
            postcss: {
                plugins: [
                    tailwindcss(),
                    autoprefixer()
                ]
            }
        },
        build: {
            outDir: '../GreenCodeBlueprint.Web.UI/wwwroot/app',
            emptyOutDir: true,
            manifest: true,
            rollupOptions: {
                input: {
                    main: resolve(__dirname, 'src/main.ts'),
                },
            },
        },
    };

    if (mode === 'development') {
        // only get the certificate if we're in development mode
        const cert = getAspDotNetCertificate();

        config.server = {
            strictPort: true,
            hmr: {
                clientPort: 5173,
            },
            https: {
                cert: cert.certificate,
                key: cert.privateKey,
            },
        };
    }

    return config;
});