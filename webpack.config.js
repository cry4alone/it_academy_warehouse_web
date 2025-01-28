const path = require("path");
const HTMLWebpackPlugin = require("html-webpack-plugin");

module.exports = {

    entry: "./src/index.js",
    output: {
        path: path.join(__dirname, "/dist"),
        filename: "bundle.js",
    },

    plugins: [
        new HTMLWebpackPlugin({
            template: "./src/index.html",
        }),
    ],

    devServer: {
        port: 8080,
        historyApiFallback: true,
    },

    module: {
        rules: [
            {
                test: /.js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader",
                    options: {
                        presets: ["@babel/preset-env", "@babel/preset-react"],
                    }
                }
            },
            {
                test: /\.svg$/, 
                type: 'asset/resource',
            },
            {
                test: /\.scss$/,
                use: ["style-loader", "css-loader", "sass-loader"],
<<<<<<< HEAD
            }
            
=======
            },
            {
                test: /\.css$/,
                use: ["style-loader", "css-loader"],
            },
>>>>>>> 78c94d6e93668807d0c55491bc45785a66493e04
        ]
    }
};