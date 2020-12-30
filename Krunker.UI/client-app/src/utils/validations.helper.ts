export const isNotEmptyString = (val: string) => Boolean(val.trim().length);
export const isAlphaNumericWithSpace = (val: string) =>
	/^[a-z0-9 ]+$/i.test(val);
export const isFirstCharLetter = (val: string) => /^[a-z]/i.test(val);
export const isInLengthLimits = (val: string, min = 3, max = 15) =>
	val.length >= min && val.length <= max;
export const isValidName = (val: string) =>
	isNotEmptyString(val) &&
	isAlphaNumericWithSpace(val) &&
	isFirstCharLetter(val) &&
	isInLengthLimits(val);
export const is4DigitYear = (val: string) => /^[1-9][0-9]{3}$/.test(val);
export const isGreaterThanZero = (val: string | number) => Number(val) > 0;
export const isNonNegativeNumber = (val: string | number) => Number(val) >= 0;
export const isFileLessThanOrEquals5MB = (file: File) =>
	file?.size / 1024 / 1024 <= 5;
export const isFileAnImage = (file: File) => file?.type?.includes("image");
export const isValidFile = (file: File) =>
	isFileLessThanOrEquals5MB(file) && isFileAnImage(file);
