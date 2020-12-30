<template>
    <div class="toast">
        <div class="toast__info">
            <p>{{ msg }}</p>
        </div>
        <div class="toast__action">
            <button @click="close">OK</button>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, onUnmounted } from "vue";

const component = defineComponent({
    name: "Toast",
    props: {
        msg: {
            type: String,
            required: true
        }
    },
    emits: ["close"],
    setup(_, { emit }) {
        const close = () => emit("close");
        const closer = setTimeout(close, 5000);
        onUnmounted(() => {
            clearTimeout(closer);
        });
        return { close };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.toast {
    width: 90%;
    max-width: 25rem;
    background: rgba($color: $dark, $alpha: 0.9);
    border-radius: $toastRadius;
    position: absolute;
    bottom: 2rem;
    left: 50%;
    transform: translateX(-50%);
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 0 1rem;
    z-index: 45;
    &__info {
        color: $light;
    }
    &__action button {
        color: $light;
        outline: none;
        border: none;
        border-radius: $toastRadius;
        background: rgba($color: $good, $alpha: 0);
        padding: 0.5rem 0.9rem;
        cursor: pointer;
        transition: all 400ms ease-in-out;
        &:hover,
        &:focus,
        &:active {
            background: rgba($color: $good, $alpha: 0.5);
        }
    }
}
</style>