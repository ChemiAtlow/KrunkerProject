<template>
    <side-nav-view>
        <template #menu>
            <admin-menu />
        </template>
        <template #content>
            <router-view />
        </template>
    </side-nav-view>
</template>

<script lang="ts">
import { defineComponent, defineAsyncComponent } from "vue";

const AdminMenu = defineAsyncComponent({
    loader: () =>
        import(
            /* webpackChunkName: "group-admin" */ "@/components/AdminMenu/index.vue"
        )
});

const component = defineComponent({
    name: "Admin",
    components: { AdminMenu }
});

export default component;
</script>

<style lang="scss">
</style>
