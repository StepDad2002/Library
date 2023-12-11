/** @type {import('tailwindcss').Config} */
module.exports = {
    mode: 'jit',
    content: [
        "../../Views/*.cshtml",
        "../../Views/**/*.cshtml"
    ],
    theme: {
        extend: {
            spacing: {
                "188": "54.5rem",
                "128": "32rem"
            }
        },
    },
    plugins: [],
}

