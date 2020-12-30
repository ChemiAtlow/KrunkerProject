<template>
    <div class="main-header">
        <h1 class="main-header__brand">Shop</h1>
        <div class="main-header__items">
            <router-link class="main-header__items-item" to="/">
                Home
            </router-link>
            <router-link class="main-header__items-item" to="/cart">
                cart
            </router-link>
            <router-link class="main-header__items-item" to="/admin">
                admin
            </router-link>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

const component = defineComponent({
    name: "NavBar"
});
export default component;
</script>

<style lang="scss" scoped>
.main-header {
    background: $primary;
    padding: 0.5rem 1rem;
    display: flex;
    align-items: center;
    justify-content: space-between;
    box-shadow: 0 0.1rem 0.5rem $primaryLight;
    &__brand {
        text-transform: uppercase;
        font-weight: bold;
        color: $light;
        text-shadow: 0.2rem 0.2rem 0.2rem $primaryLight2;
    }
    &__items {
        margin: 0;
        padding: 0;
        list-style: none;
        display: flex;
        &-item {
            margin: 0 1rem;
            text-decoration: none;
            color: $lightGray;
            font-weight: bold;
            text-transform: capitalize;
            padding: 0.2rem 0;
            transition: 400ms all ease-in-out;
            &:hover,
            &.router-link-active {
                border-bottom: 3px solid $light;
                color: $light;
            }
        }
    }
}
</style>