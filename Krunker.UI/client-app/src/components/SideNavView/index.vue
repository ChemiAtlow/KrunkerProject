<template>
    <div class="side-nav__view">
        <div class="side-nav__view-menu">
            <slot name="menu" />
        </div>
        <div class="side-nav__view-content">
            <slot name="content" />
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

const component = defineComponent({
    name: "SideNavView"
});

export default component;
</script>

<style lang="scss" scoped>
.side-nav__view {
    display: grid;
    height: 100%;
    width: 100%;
    overflow: hidden;
    grid-template-columns: 18rem 1fr;
    grid-template-areas: "menu content";
    &-menu {
        grid-area: menu;
        height: 100%;
        background: $light;
        position: relative;
        overflow: hidden;
    }
    &-content {
        grid-area: content;
        height: 100%;
        position: relative;
        overflow: hidden;
    }
}
</style>