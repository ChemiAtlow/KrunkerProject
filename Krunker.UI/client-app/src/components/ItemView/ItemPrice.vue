<template>
    <div class="price">
        <span v-if="discount" class="price__original"
            >{{ prettyNumber(originalPrice) }}$</span
        >
        <span class="price__calculated"
            >{{ prettyNumber(calculatedPrice) }}$</span
        >
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from "vue";
import { prettyNumber } from "@/utils";

const component = defineComponent({
    name: "ItemPrice",
    props: {
        price: {
            type: Number,
            required: true
        },
        discount: {
            type: Number,
            required: true
        },
        amount: {
            type: Number,
            default: () => 1
        },
        type: {
            type: String as () => "purchase" | "product",
            default: () => "product"
        }
    },
    setup(props) {
        const priceAmount = computed(() =>
            props.type === "purchase" ? props.amount : 1
        );
        const originalPrice = computed(() =>
            props.type !== "purchase"
                ? props.price * priceAmount.value
                : props.price * priceAmount.value +
                  (props.price * priceAmount.value * props.discount) / 100
        );
        const calculatedPrice = computed(() =>
            props.type === "purchase"
                ? props.price * priceAmount.value
                : props.price * priceAmount.value -
                  (props.price * priceAmount.value * props.discount) / 100
        );
        return { priceAmount, originalPrice, calculatedPrice, prettyNumber };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.price {
    margin: 0.4rem;
    &__original {
        text-decoration: line-through;
        color: $error;
        margin-right: 0.4rem;
    }
    &__calculated {
        font-size: 1.3rem;
    }
}
</style>