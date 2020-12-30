import { reactive } from "vue";

const state = reactive<{ toastMsg: string }>({ toastMsg: "" });

const clearToast = () => {
	state.toastMsg = "";
};

const showToast = (msg: string) => {
	clearToast();
	state.toastMsg = msg;
};

export const messagesService = { state, showToast, clearToast };
