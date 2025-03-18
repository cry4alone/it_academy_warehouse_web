import pluginJs from "@eslint/js";
import pluginReact from "eslint-plugin-react";
import pluginTs from "@typescript-eslint/eslint-plugin";
import parserTs from "@typescript-eslint/parser";
import globals from "globals";

/** @type {import('eslint').Linter.Config[]} */
export default [
  {
    files: ["**/*.{js,mjs,cjs,jsx}"],
    languageOptions: {
      parser: pluginJs.parser,
      parserOptions: {
        ecmaVersion: 2021,
        sourceType: "module",
        ecmaFeatures: {
          jsx: true,
        },
      },
      globals: { ...globals.browser, ...globals.node },
    },
    plugins: {
      react: pluginReact,
    },
    rules: {
      ...pluginJs.configs.recommended.rules,
      ...pluginReact.configs.recommended.rules,
    },
    settings: {
      react: {
        version: "detect",
      },
    },
  },
  {
    files: ["**/*.{ts,tsx}"],
    languageOptions: {
      parser: parserTs,
      parserOptions: {
        ecmaVersion: 2021,
        sourceType: "module",
        ecmaFeatures: {
          jsx: true,
        },
        project: "./tsconfig.json",
      },
      globals: { ...globals.browser, ...globals.node },
    },
    plugins: {
      "@typescript-eslint": pluginTs,
      react: pluginReact,
    },
    rules: {
      ...pluginTs.configs.recommended.rules,
      ...pluginReact.configs.recommended.rules,
      "@typescript-eslint/no-explicit-any": "off"
    },
    settings: {
      react: {
        version: "detect",
      },
    },
  },
  {
    ignores: ["dist/", "tsconfig.json"],
  },
];
