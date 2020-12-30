<template>
    <div class="badge" :class="`badge__${type}`">{{ value }}</div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

const component = defineComponent({
    name: "Badge",
    props: {
        value: {
            type: String,
            required: true
        },
        type: {
            type: String as () => "info" | "warn" | "good",
            default: () => "info"
        }
    }
});
export default component;
</script>

<style lang="scss" scoped>
.badge {
    position: absolute;
    top: 0;
    right: 0;
    margin: 0;
    padding: 0.5rem;
    transform: rotateZ(45deg) translate(3.5rem, -2rem);
    font-size: 0.75rem;
    text-transform: uppercase;
    width: 12rem;
    background: $dark;
    color: $light;
    &__good {
        background: $good;
    }
    &__warn {
        background: $error;
    }
}
</style>