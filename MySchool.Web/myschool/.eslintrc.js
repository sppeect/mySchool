module.exports = {
  root: false,
  env: {
    node: true
  },
  extends: [
    'plugin:vue/essential',
    '@vue/standard'
  ],
  parserOptions: {
    parser: '@babel/eslint-parser'
  },
  rules: {
    'no-console': 'off',
    'no-warning-comments': 'off',
    'no-console': process.env.NODE_ENV === 'development' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'development' ? 'warn' : 'off',
    'vue/multi-word-component-names': 0,
    indent: [2, "tab"],
    "no-tabs": 0,
  }
}
