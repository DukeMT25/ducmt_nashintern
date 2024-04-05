module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
        './Areas/Admin/Views/**/*.cshtml',
    ],
    theme: {
        extend: {},
        container: {
            center: true,
        },
    },
    plugins: [require("daisyui")],

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
