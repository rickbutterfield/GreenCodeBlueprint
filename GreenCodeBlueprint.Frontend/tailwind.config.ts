/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "../GreenCodeBlueprint.Web.UI/Views/**/*.cshtml",
        "./src/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        fontFamily: {
            'sans': 'InterVariable, Inter, ui-sans-serif, system-ui, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"',
            'display': 'InterDisplay, InterVariable, Inter, ui-sans-serif, system-ui, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"'
        },
        extend: {
            colors: {
                'midnight': {
                    '50': '#e9fbff',
                    '100': '#cef5ff',
                    '200': '#a7efff',
                    '300': '#6beaff',
                    '400': '#26d8ff',
                    '500': '#00b4ff',
                    '600': '#008aff',
                    '700': '#006fff',
                    '800': '#005fe6',
                    '900': '#0055b3',
                    '950': '#001f3f',
                },
                'salem': {
                    '50': '#ecfff7',
                    '100': '#d3ffed',
                    '200': '#aaffdd',
                    '300': '#69ffc4',
                    '400': '#21ffa5',
                    '500': '#00f286',
                    '600': '#00ca6b',
                    '700': '#009e57',
                    '800': '#00804c',
                    '900': '#02653e',
                    '950': '#003920',
                },
                'bianca': {
                    '50': '#f6f7ed',
                    '100': '#ebedd8',
                    '200': '#d6daad',
                    '300': '#c2c683',
                    '400': '#b7b966',
                    '500': '#ada753',
                    '600': '#988a47',
                    '700': '#7f6e3e',
                    '800': '#695937',
                    '900': '#584a2f',
                    '950': '#312817',
                },
                'mantis': {
                    '50': '#f4fbf2',
                    '100': '#e5f6e2',
                    '200': '#cdecc6',
                    '300': '#a4dc99',
                    '400': '#74c365',
                    '500': '#50a740',
                    '600': '#3e8930',
                    '700': '#336c29',
                    '800': '#2c5724',
                    '900': '#25481f',
                    '950': '#0f270c',
                },
            }
        },
    },
    plugins: [
        require('@tailwindcss/aspect-ratio'),
        require('@tailwindcss/typography'),
    ],
}