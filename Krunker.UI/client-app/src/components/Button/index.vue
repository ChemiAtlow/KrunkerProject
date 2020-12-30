<template>
    <button :class="{ light, primary }"><slot /></button>
</template>

<script lang="ts">
import { defineComponent } from "vue";

const component = defineComponent({
    name: "AppButton",
    props: {
        light: {
            type: Boolean
        },
        primary: {
            type: Boolean
        }
    }
});

export default component;
</script>

<style lang="scss" scoped>
button {
    padding: 0.5rem 1rem;
    outline: none;
    background: rgba($color: $light, $alpha: 0.6);
    font-size: 1rem;
    margin: 0 0.5rem;
    border: 2px solid $primary;
    border-radius: 0.2rem;
    transition: all 400ms ease-in-out;
    cursor: pointer;
    &.light {
        background: rgba(255, 255, 255, 0.6);
    }
    &.primary {
        background: rgba($color: $primary, $alpha: 0.6);
        color: #fff;
    }
    &:hover,
    &:active,
    &:focus {
        &:not(:disabled) {
            background: $light;
            &.light {
                background: #fff;
            }
            &.primary {
                background: $primary;
            }
        }
    }
    &:disabled {
        cursor: auto;
        background: $lightGray;
    }
}
</style>