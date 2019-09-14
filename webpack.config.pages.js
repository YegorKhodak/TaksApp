// Webpack v4

const path = require('path');
const webpack = require('webpack');
const { CheckerPlugin } = require('awesome-typescript-loader');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const devMode = process.env.NODE_ENV !== 'production';

module.exports = {
    entry: {
        //vendorCss: ["./Styles/bootstrap.scss"],
        //layoutCss: ["./Styles/layoutCss.scss"],
        //layout: ["./Scripts/layout"],
        auth: ["./Scripts/auth"],
        createOrder: ["./Scripts/createOrder"],
        confirmOrderByAdmin: ["./Scripts/confirmOrderByAdmin"],
    },

    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'wwwroot/dist/')
    },

    module: {
        rules: [
            {
                test: /\.tsx?$/,
                loader: 'awesome-typescript-loader'
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            },
            {
                test: /\.(sa|sc|c)ss$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    {
                        loader: "css-loader" // translates CSS into CommonJS
                    },
                    {
                        loader: "postcss-loader", // compiles Sass to CSS
                        options:
                        {
                            //publicPath: "./css/"
                            options: {
                            }
                        }
                    },
                    {
                        loader: "sass-loader" // compiles Sass to CSS
                    }
                ]
            },
            {
                test: /\.(png|jpg|gif|woff|woff2|eot|ttf|svg)$/i,
                use: [
                    {
                        loader: 'url-loader',
                        options: {
                            limit: 100000
                        }
                    }
                ]
            }
        ]
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.js', '.jsx'],
        alias: {
            'jquery': path.join(__dirname, 'node_modules/jquery/dist/jquery'),
            "jquery-ui": "node_modules/jquery-ui/jquery-ui.js"
        }
    },
    devtool: 'source-map',
    plugins: [
        new CheckerPlugin(),
        new MiniCssExtractPlugin({
            filename: devMode ? '[name].css' : '[name].[hash].css',
            path: path.resolve(__dirname, 'wwwroot/dist/css/'),
            chunkFilename: devMode ? '[id].css' : '[id].[hash].css'
        })
    ],
    optimization: {
        splitChunks: {
            chunks: 'all', //chunks can be shared even between async and non-async chunks
            minChunks: 1, //Minimum number of chunks that must share a module before splitting. 1 is a default value. 
            cacheGroups: {
                vendor: {
                    test: /[\\/]node_modules[\\/]/,
                    chunks: "initial",
                    name: "vendor",
                    enforce: true
                }
            }
        }
    }
};