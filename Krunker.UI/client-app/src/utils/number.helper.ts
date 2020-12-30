export const prettyNumber = (val: number) => {
	const num = Number(val);
	return num?.toLocaleString(undefined, { maximumFractionDigits: 2 }) || 0;
};
