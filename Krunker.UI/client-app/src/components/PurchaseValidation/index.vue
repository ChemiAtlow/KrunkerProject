<template>
    <div>
        <h3>{{ item.name }} purchase details:</h3>
        <form-field
            label="Amount to purchase"
            type="number"
            :model-value="modelValue"
            @update:model-value="$emit('update:modelValue', $event)"
            :validator="validators.isGreaterThanZero"
            @validity-change="$emit('validityChange', $event)"
        />
        <p v-if="item.discount">
            You have {{ item.discount }}% discount for this purchase!
        </p>
        <p v-if="modelValue > 0">
            The total price would be: {{ prettyNumber(calculatedPrice) }}
        </p>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from "vue";
import type { ShoppingItem } from '@/models';
import { validators, prettyNumber } from '@/utils';

const component = defineComponent({
    name: "PurchaseValidation",
    emits: ["update:modelValue", "validityChange"],
    props: {
        modelValue: {
            type: Number,
            required: true,
        },
        item: {
            type: Object as () => ShoppingItem,
            required: true,
        }
    },
    setup(props) {
        const calculatedPrice = computed(() => props.item.price * props.modelValue - (props.item.price * props.modelValue * props.item.discount / 100));
        return { validators, calculatedPrice, prettyNumber };
    }
})

export default component;
</script>

<style lang="scss" scoped>
</style>