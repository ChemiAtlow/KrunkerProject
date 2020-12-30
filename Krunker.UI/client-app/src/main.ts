import { createApp, defineAsyncComponent } from "vue";
import App from "./App.vue";
import router from "./router";
import Button from "@/components/Button/index.vue";
import SideNavView from "@/components/SideNavView/index.vue";
import ItemView from "@/components/ItemView/index.vue";
import ToggleSwitch from "@/components/Switch/index.vue";
import AppSelect from "@/components/Select/index.vue";
import FormField from "@/components/ItemForm/FormField.vue";

const EmptyView = defineAsyncComponent({
	loader: () =>
		import(
			/* webpackChunkName: "group-empty" */ "@/components/EmptyView/index.vue"
		),
});
const Modal = defineAsyncComponent({
	loader: () =>
		import(
			/* webpackChunkName: "group-modal" */ "@/components/Modal/index.vue"
		),
});

createApp(App)
	.use(router)
	.component("AppButton", Button)
	.component("AppSelect", AppSelect)
	.component("ToggleSwitch", ToggleSwitch)
	.component("FormField", FormField)
	.component("SideNavView", SideNavView)
	.component("EmptyView", EmptyView)
	.component("ItemView", ItemView)
	.component("Modal", Modal)
	.mount("#app");
