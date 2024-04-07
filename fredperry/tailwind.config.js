module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
        './Areas/Admin/Views/**/*.cshtml',
        './Areas/Identity/Pages/**/*.cshtml',
        './Areas/Customer/Views/**/*.cshtml',
    ],
    theme: {
        extend: {},
        container: {
            center: true,
        },
    },
    plugins: [
        require("daisyui"),
        require('@tailwindcss/aspect-ratio'),
    ],

    daisyui: {
        themes: ["light", "dark", "cyberpunk"],
        darkTheme: "dark",
        base: true, 
        styled: true, 
        utils: true, 
        prefix: "", 
        logs: true, 
        themeRoot: ":root",
    },
}
