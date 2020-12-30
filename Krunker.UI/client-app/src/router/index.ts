import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Home from "../views/Home.vue";
const Admin = () =>
	import(/* webpackChunkName: "group-admin" */ "@/views/Admin.vue");
const AdminItemForm = () =>
	import(
		/* webpackChunkName: "group-admin" */ "@/components/ItemForm/index.vue"
	);
const AdminItemView = () =>
	import(
		/* webpackChunkName: "group-admin" */ "@/components/AdminItemView/index.vue"
	);
const AdminPurchaseReports = () =>
	import(
		/* webpackChunkName: "group-admin" */ "@/components/PurchaseReports/index.vue"
	);
const Error = () =>
	import(/* webpackChunkName: "group-error" */ "@/views/Error.vue");
const Cart = () =>
	import(/* webpackChunkName: "group-cart" */ "@/views/Cart.vue");

const routes: Array<RouteRecordRaw> = [
	{
		path: "/",
		name: "Home",
		component: Home,
	},
	{
		path: "/admin",
		name: "Admin",
		component: Admin,
		children: [
			{
				path: "new",
				name: "AdminNewItem",
				component: AdminItemForm,
			},
			{
				path: "reports",
				name: "AdminReports",
				component: AdminPurchaseReports,
			},
			{
				path: ":id?",
				name: "AdminItemView",
				component: AdminItemView,
			},
		],
	},
	{
		path: "/cart",
		name: "Cart",
		component: Cart,
	},
	{
		path: "/:pathMatch(.*)*",
		name: "NotFound",
		component: Error,
	},
];

const router = createRouter({
	history: createWebHistory(process.env.BASE_URL),
	routes,
});

export default router;
