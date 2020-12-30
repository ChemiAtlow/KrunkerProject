<template>
    <div class="filter">
        {{ title }}
        <toggle-switch
            v-if="type === 'switch'"
            :mode="current"
            @update:mode="current = $event"
        />
        <app-select
            v-else
            :options="options"
            @update:modelValue="current = $event"
            :modelValue="current"
        />
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from "vue";

const component = defineComponent({
    name: "Filter",
    emits: ["update:modelValue"],
    props: {
        title: {
            type: String,
            required: true
        },
        options: {
            type: Array as () => string[],
            default: () => []
        },
        type: {
            type: String as () => "switch" | "selection",
            default: () => "selection"
        },
        modelValue: {
            required: true
        }
    },
    setup(props, { emit }) {
        const current = computed({
            get: () => props.modelValue,
            set: val => {
                emit("update:modelValue", val);
            }
        });
        return { current };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.filter {
    margin: 1rem;
    display: grid;
    align-items: center;
    text-align: left;
    grid-template-columns: 1fr 6.6rem;
}
</style>