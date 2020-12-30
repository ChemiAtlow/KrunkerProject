const isNotNumber = (val: string | number) => !isNaN(Number(val));

export const getEnumKeys = (e: { [key: number]: string }) =>
	Object.keys(e)
		.filter(isNotNumber)
		.map(key => e[(key as unknown) as number]);
