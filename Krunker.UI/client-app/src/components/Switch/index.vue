<template>
    <div class="toggle" :class="{ checked: mode }" @click="toggle">
        <div class="toggle__bubble"></div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
const component = defineComponent({
    name: "Switch",
    emits: ["update:mode"],
    props: {
        mode: {
            type: Boolean,
            default: false
        }
    },
    setup(props, { emit }) {
        const toggle = () => {
            const newMode = !props.mode;
            emit("update:mode", newMode);
        };
        return { toggle };
    }
});
export default component;
</script>

<style lang="scss">
.toggle {
    height: $toggleHeight;
    width: $toggleWidth;
    position: relative;
    display: flex;
    background-color: $gray;
    border: 1px solid $gray;
    box-shadow: 0 0 4px $primary;
    box-sizing: content-box;
    border-radius: $toggleRadius;
    background-clip: padding-box;
    overflow: hidden;
    cursor: pointer;
    transition: $toggleTransition;
    &.checked {
        background-color: $dark;
    }
    &__bubble {
        position: absolute;
        width: $toggleBubbleWidth;
        height: $toggleBubbleWidth;
        top: 2px;
        left: 2px;
        border-radius: 50%;
        background-clip: padding-box;
        background: white;
        box-shadow: 0 1px 3px rgba(0, 0, 0, 0.4);
        z-index: 1;
        transition: $toggleTransition;
        &::after {
            width: 0;
            height: 0;
            top: 13px;
            left: 9px;
            position: absolute;
            border-left: 2px solid $dark;
            border-bottom: 2px solid $dark;
            content: " ";
            transform: rotate(-45deg);
            transition: height 0.15s ease,
                left 0.15s cubic-bezier(0, 0.55, 0, 1.17), width 0.15s 0.15s,
                top 0.15s 0.15s;
            opacity: 0;
        }
        .checked & {
            left: 19px;
            &::after {
                top: 9px;
                left: 7px;
                width: 13px;
                height: 7px;
                opacity: 1;
            }
        }
    }
}
</style>