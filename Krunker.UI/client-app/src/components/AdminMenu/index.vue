<template>
    <ul class="admin__menu">
        <router-link
            :to="{ name: 'AdminItemView' }"
            custom
            v-slot="{ navigate, isActive }"
        >
            <li
                class="admin__menu-item"
                :class="{ active: isActive }"
                @click="navigate"
            >
                Edit items
            </li>
        </router-link>
        <router-link
            :to="{ name: 'AdminNewItem' }"
            custom
            v-slot="{ navigate, isActive }"
        >
            <li
                class="admin__menu-item"
                :class="{ active: isActive }"
                @click="navigate"
            >
                Create new item
            </li>
        </router-link>
        <router-link
            to="/admin/reports"
            custom
            v-slot="{ navigate, isExactActive }"
        >
            <li
                class="admin__menu-item"
                :class="{ active: isExactActive }"
                @click="navigate"
            >
                Reports
            </li>
        </router-link>
    </ul>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useRouter } from "vue-router";
import { Guid } from "@/models";

const component = defineComponent({
    name: "AdminMenu",
    setup() {
        const router = useRouter();

        const route = router.currentRoute;
        const navigateTo = (name: string) => router.push({ name });

        return { route, navigateTo, Guid };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.admin__menu {
    margin: 0;
    padding: 0;
    list-style: none;
    &-item {
        font-size: 1.15rem;
        text-align: left;
        cursor: pointer;
        padding: 1rem;
        color: $dark;
        transition: background-color 400ms ease-in-out;
        &:hover,
        &:focus,
        &.active {
            background-color: $primaryLight2;
        }
    }
}
</style>