# GreenCodeBlueprint

This project was released in tandem with my talk **"Green Code: A Blueprint for Eco-Friendly websites"**, first given at [Codegarden 2024](https://codegarden.umbraco.com).

> Sustainability is a hot topic, and lots of great talks have scratched the surface. In this talk, we dive into the practical application of green code with real world examples we can apply to everyday software development, and how those intersect with performance and accessibility.
>
> This talk will demonstrate how to make practical changes to your code (with live demos!) to make a tangible difference in your work based on up and coming standards such as the Web Sustainability Guidelines 1.0 and Low Impact Manifesto. We'll learn how to implement better caching, lazy loading, iframe facades, use MiniProfiler testing, optimse images and async all the things.
>
> Grounded in real world examples, this talk will encourage people to embrace green code both from the start of a project and in day-to-day support, whether you have 30 minutes or $30k to play with.

The aim is that it follows some of the best practice encouraged today, specifically from the [Web Sustainability Guidelines 1.0](https://w3c.github.io/sustyweb/) and the [Low Impact Manifesto](https://github.com/Organic-Basics/ob-low-impact-website?tab=readme-ov-file#low-impact-manifesto) and can produce a good result from tools like the [Website Carbon Calculator](https://websitecarbon.com).

## The Low Impact Manifesto
The [Low Impact Manifesto](https://github.com/Organic-Basics/ob-low-impact-website) states that a low impact website:

### 1. Does not load any images before they are actively requested by the user. 
`loading="lazy"` has been implemented on images throughout this demo site.

### 2. Minimizes the power consumption on the users device.
There are a number of things you can do to lower power consumption:
- check long running/slow running scripts
- MiniProfiler
- async all the things
- don't do something in JS that can be done in CSS

### 3. Adapts to reflect the amount of renewable energy it�s currently running on.
There is the start of an example of this within `HeroBanner.cshtml`, using the [CarbonIntensityUK](https://github.com/jordansrowles/CarbonIntensityUK) NuGet package to determine the current load of the network within the London region (assuming your server is based in the UK/on Azure UK South)

### 4. Informs the user of the impact of their browsing behavior.
Nothing too specific exists on this site (other than the behaviour above) but you can check out [herning.dk](https://herning.dk)&mdash;winner of the Green Award at Codegarden 2023&mdash;for an example of their 'Reduce your site's climate footprint' mode.

### 5. Does not make use of videos.
Just get rid of videos, or at least stop them autoplaying and use a facade! See [lite-youtube-embed](https://github.com/paulirish/lite-youtube-embed) for a great, modern example.

### 6. Stores data locally on the user�s device to minimize data transfer.
A [Service Worker](https://developer.mozilla.org/en-US/docs/Web/API/Service_Worker_API/Using_Service_Workers) is configured to locally cache styles, scripts, images coming from Umbraco and more. See [`sw.js`](https://github.com/rickbutterfield/GreenCodeBlueprint/blob/master/GreenCodeBlueprint.Web.UI/wwwroot/sw.js) for the specific setup.

### 7. Compresses all data to the greatest extent possible.
- image cropping
- minified CSS/JS

### 8. Loads only the most crucial programming scripts, frameworks and cookies.
Don't load Google Maps on every page if you're only using it on your contact page!

### 9. Limits the amount of light emitted by the screen.
Dark mode baby! First class citizen on the web since 2018, and there is the start of changing some components on the site to use Tailwind's `dark:` modifier.

There is also an example in [`style.scss`](https://github.com/rickbutterfield/GreenCodeBlueprint/blob/master/GreenCodeBlueprint.Frontend/src/scss/style.scss) of a more modern CSS/Sass approach using the new [`light-dark()` function](https://developer.mozilla.org/en-US/docs/Web/CSS/color_value/light-dark).

### 10. Optimizes and limits the use of custom fonts.
Some third party fonts are loaded in this site as an example, but the ideal would be to use a system font stack where possible, like GitHub uses:

```css
body {
  font-family: -apple-system,BlinkMacSystemFont,"Segoe UI","Noto Sans",Helvetica,Arial,sans-serif,"Apple Color Emoji","Segoe UI Emoji";
}
```

See [systemfontstack.com](https://systemfontstack.com) for other great examples! 

## Setup
The solution should be able to be pulled and run wherever .NET is installed.

The site uses Umbraco v13.3.2, with a front end build runner using Vite [based on this excellent article from Erica Quessenberry](https://skrift.io/issues/vite-and-umbraco-v13/). A Vite `watch` process runs automatically in `Development` mode.

The site uses SQLite and content will automatically be imported using [uSync First Boot](https://docs.jumoo.co.uk/usync/uSync/guides/firstboot).
