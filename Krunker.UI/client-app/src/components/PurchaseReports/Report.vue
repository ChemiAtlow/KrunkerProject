<template>
    <div class="report-wrapper">
        <div class="report">
            <div class="report__number">{{ index }}.</div>
            <div class="report__name">
                Purchase - {{ report.id.split("-")[0] }}
            </div>
            <div class="report__time">
                {{ prettyDate(report.purchaseTime) }}
            </div>
            <div class="report__price">
                Total - {{ prettyNumber(report.totalPrice) }}$
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { ShoppingCart } from "@/models";
import { prettyNumber, prettyDate } from "@/utils";

const component = defineComponent({
    name: "Report",
    props: {
        index: {
            type: Number,
            required: true
        },
        report: {
            type: Object as () => ShoppingCart,
            required: true
        }
    },
    setup() {
        return { prettyNumber, prettyDate };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.report-wrapper {
    margin: 0.5rem;
    height: $barHeight;
    .report {
        height: 100%;
        display: grid;
        border-radius: 0.3em;
        background: $primaryLight;
        color: $light;
        box-shadow: 0 0 0.8rem $shadowGray;
        cursor: pointer;
        overflow: hidden;
        grid-template-columns: 3rem repeat(3, 1fr);
        align-items: center;
        transition: background-color 400ms ease-in-out;
        &__number {
            height: 100%;
            display: flex;
            align-items: center;
            justify-content: center;
            background: $primaryLight2;
        }
        &:hover {
            background: $dark;
        }
    }
}
</style>