<template>
    <div class="form-field">
        <label class="form-field__label" :class="{ invalid: !isValid }">
            {{ label }}
            <app-select
                v-if="Array.isArray(type)"
                :options="type"
                @update:modelValue="$emit('update:modelValue', $event)"
                :modelValue="modelValue"
            />
            <toggle-switch
                v-else-if="type === 'checkbox'"
                :mode="modelValue"
                @update:mode="$emit('update:modelValue', $event)"
            />
            <input
                v-else-if="type === 'file'"
                type="file"
                @input="fileChange($event.target.files?.[0])"
            />
            <input
                v-else
                :type="type"
                :value="modelValue"
                @input="$emit('update:modelValue', $event.target.value)"
            />
        </label>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed, ref } from "vue";

const component = defineComponent({
    name: "FormField",
    emits: ["update:modelValue", "validityChange"],
    props: {
        label: {
            type: String,
            required: true
        },
        type: {
            required: true
        },
        modelValue: {
            required: true
        },
        validator: {
            type: Function,
            default: () => true
        }
    },
    setup(props, { emit }) {
        const fileTmp = ref<File>();
        const isRegularInput = computed(
            () => !Array.isArray(props.type) && props.type !== "checkbox"
        );
        const fileChange = (file?: File) => {
            fileTmp.value = file;
            emit("update:modelValue", file);
        };
        const isValid = computed(() => {
            const isValid =
                !isRegularInput.value ||
                (props.type === "file" && props.validator(fileTmp.value)) ||
                (props.type !== "file" && props.validator(props.modelValue));
            emit("validityChange", isValid);
            return isValid;
        });
        return { fileChange, isValid };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.form-field {
    margin: 1rem 0;
    &__label {
        display: grid;
        align-items: center;
        grid-template-columns: 1fr 1fr;
        & input {
            width: 100%;
            height: 2.5rem;
            font-size: 1.1rem;
            background-color: $gray;
            border-radius: 0.4rem;
            border: 1px solid $primaryLight;
            outline: none;
            color: $primaryLight;
            padding-left: 0.5rem;
            &:hover,
            &:focus {
                background-color: darken($color: $gray, $amount: 20);
            }
        }
        &.invalid {
            color: $error;
            & input {
                background-color: rgba($color: $error, $alpha: 0.2);
                border-color: $error;
                color: $error;
                &:hover,
                &:focus {
                    background-color: rgba($color: $error, $alpha: 0.4);
                }
            }
        }
    }
}
</style>