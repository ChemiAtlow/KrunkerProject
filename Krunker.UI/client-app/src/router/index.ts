import {
	createRouter,
	createWebHashHistory,
	createWebHistory,
} from "vue-router";
import { routes } from "./routes";

const historyCreator =
	process.env.NODE_ENV === "production"
		? createWebHashHistory
		: createWebHistory;

const router = createRouter({
	history: historyCreator(process.env.BASE_URL),
	routes,
});

export default router;
