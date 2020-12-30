<template>
    <div class="custom-select" :tabindex="tabindex" @blur="open = false">
        <div
            class="selected"
            :title="englishify(modelValue)"
            :class="{ open: open }"
            @click="toggle"
        >
            <p class="selected__value">
                {{ englishify(modelValue) }}
            </p>
        </div>
        <div class="items" v-if="open">
            <div
                v-for="(option, i) of options"
                :key="i"
                :title="englishify(option)"
                @click="select(option)"
            >
                {{ englishify(option) }}
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";

const component = defineComponent({
    name: "AppSelect",
    emits: ["update:modelValue"],
    props: {
        options: {
            type: Array as () => string[],
            required: true
        },
        modelValue: {
            type: String,
            required: true
        },
        tabindex: {
            type: Number,
            required: false,
            default: () => 0
        }
    },
    setup(props, { emit }) {
        const open = ref(false);
        const select = (option: string) => {
            open.value = false;
            emit("update:modelValue", option);
        };
        const englishify = (val: string) =>
            val
                .replace(/[0-9]{2,}/g, match => ` ${match} `)
                .replace(/[^A-Z0-9][A-Z]/g, match => `${match[0]} ${match[1]}`)
                .replace(
                    /[A-Z][A-Z][^A-Z0-9]/g,
                    match => `${match[0]} ${match[1]}${match[2]}`
                )
                .replace(/[ ]{2,}/g, () => " ")
                .replace(/\s./g, match => match.toUpperCase())
                .replace(/^./, match => match.toUpperCase())
                .trim();
        const toggle = () => {
            if (!props.options.length) return;
            open.value = !open.value;
        };
        return { select, open, toggle, englishify };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.custom-select {
    position: relative;
    width: 100%;
    text-align: left;
    outline: none;
    min-height: 2.5rem;
    line-height: 2.5rem;
    .selected {
        width: 100%;
        height: 2.5rem;
        background-color: $gray;
        border-radius: 0.4rem;
        border: 1px solid $primaryLight;
        color: $primaryLight;
        padding-left: 0.5rem;
        cursor: pointer;
        user-select: none;
        &__value {
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
            margin: 0 1.1rem 0 0;
        }
        &.open {
            border: 1px solid $primaryLight2;
            border-radius: 6px 6px 0px 0px;
        }
        &::after {
            position: absolute;
            content: "";
            top: 50%;
            right: 0.5rem;
            transform: translateY(-25%);
            width: 0;
            height: 0;
            border: 5px solid transparent;
            border-top-color: $primaryLight;
        }
    }
    .items {
        color: $primaryLight;
        border-radius: 0px 0px 6px 6px;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        border: 1px solid $primaryLight2;
        border-top: 0 solid transparent;
        position: absolute;
        background-color: $gray;
        left: 0;
        right: 0;
        z-index: 50;
        div {
            padding-left: 0.5rem;
            cursor: pointer;
            user-select: none;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
            &:hover {
                background-color: $primaryLight2;
            }
        }
    }
}
</style>