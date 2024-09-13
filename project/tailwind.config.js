/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: [
    './**/*.{razor,html,cshtml,js}',
    "./Components/**/*.{html,razor}",
    '!./node_modules/**/*'
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
