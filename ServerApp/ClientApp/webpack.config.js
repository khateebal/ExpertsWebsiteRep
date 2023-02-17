﻿const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: {
    site: './src/js/site.js',
    bootstrap_js: './src/js/bootstrap_js.js',
    validation: './src/js/validation.js',
    index: './src/js/index.js'
     },
output: {
    filename: '[name].entry.js',
        path: path.resolve(__dirname, '..', 'wwwroot', 'dist')
},
devtool: 'source-map',
    mode: 'development',
        module: {
    rules: [
        {
            test: /\.css$/,
            use: [{ loader: MiniCssExtractPlugin.loader }, 'css-loader'],
             },
            {
                test: /\.(eot|woff(2)?|ttf|otf|svg)$/i,
                    type: 'asset'
                },
                {
                    test: /\.js$/,
                    exclude: /(node_modules)/,
                    use: {
                        loader: 'babel-loader',
                        options: {
                            presets: ['@babel/preset-env']
                        }
                    }
                }

         ]
    },

     plugins: [
            new MiniCssExtractPlugin({
  filename: "[name].css"
            })
       ]
 };