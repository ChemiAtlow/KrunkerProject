module.exports = {
	publicPath:
		process.env.NODE_ENV === "production" ? "/KrunkerProject/" : "/",
	css: {
		loaderOptions: {
			sass: {
				additionalData: `@import "@/utils/_vars.scss";`,
			},
		},
	},
};
