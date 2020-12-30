<template>
    <h3>
        {{ report.purchases.length }} Items purchased with a total sum of
        {{ prettyNumber(report.totalPrice) }}$.
    </h3>
    <p v-for="purchase in report.purchases" :key="purchase.id">
        {{ purchase.amount }} units of {{ purchase.item.name }} with a
        {{ purchase.discountRate }}% discount.
    </p>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { prettyNumber } from "@/utils";
import type { ShoppingCart } from "@/models";

const component = defineComponent({
    name: "PurchaseDetails",
    props: {
        report: {
            type: Object as () => ShoppingCart,
            required: true
        }
    },
    setup() {
        return { prettyNumber };
    }
});

export default component;
</script>

<style lang="scss" scoped>
</style>