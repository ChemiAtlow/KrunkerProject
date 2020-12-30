<template>
    <div class="item">
        <badge v-if="badgeInfo" v-bind="{ ...badgeInfo }" />
        <h2 class="item__name">{{ name }}</h2>
        <div class="item__image">
            <img :alt="name" :src="BASE_URL + 'images/' + imgName" />
        </div>
        <div class="item__stock">
            <p>Items {{ stockText }}: {{ amount }}</p>
        </div>
        <item-price v-bind="{ price, discount, amount, type }"></item-price>
        <div class="item_actions">
            <app-button
                :disabled="amount === 0 && type !== 'admin'"
                @click="executeAction"
            >
                {{
                    type === "admin"
                        ? "Edit"
                        : (type === "purchase" ? "Remove from" : "Add to") +
                          " cart"
                }}
            </app-button>
            <app-button v-if="type === 'admin'" @click="deleteItem">
                Delete
            </app-button>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from "vue";
import { apiConstants } from "@/constants";
import { guid } from "@/models";
import Badge from "@/components/ItemView/Badge.vue";
import ItemPrice from "@/components/ItemView/ItemPrice.vue";

export default defineComponent({
    name: "ItemView",
    components: { Badge, ItemPrice },
    props: {
        id: {
            type: String as () => guid,
            required: true
        },
        type: {
            type: String as () => "purchase" | "product" | "admin",
            default: () => "product"
        },
        name: {
            required: true,
            type: String
        },
        imgName: {
            required: true,
            type: String
        },
        amount: {
            required: true,
            type: Number
        },
        price: {
            required: true,
            type: Number
        },
        discount: {
            type: Number,
            default: () => 0
        }
    },
    emits: ["actionExecuted", "deleteItem"],
    setup(props, { emit }) {
        const stockText = computed(() =>
            props.type === "purchase" ? "in cart" : "in stock"
        );
        const badgeInfo = computed(() => {
            if (props.amount === 0) {
                return { type: "warn", value: "Sold out" };
            }
            if (props.discount > 0) {
                return { type: "good", value: `${props.discount}% off` };
            }
            return;
        });
        const executeAction = () => emit("actionExecuted");
        const deleteItem = () => emit("deleteItem");
        const { BASE_URL } = apiConstants;
        return { stockText, badgeInfo, executeAction, deleteItem, BASE_URL };
    }
});
</script>

<style lang="scss" scoped>
.item {
    width: 90%;
    max-width: 20rem;
    background: $primaryLight;
    color: $light;
    box-shadow: 0 0 0.8rem $shadowGray;
    border-radius: 0.3em;
    margin: 1rem;
    padding: 1rem 0;
    position: relative;
    overflow: hidden;
    transition: all 400ms ease-in-out;
    &__name {
        padding-bottom: 1rem;
        margin: 0;
    }
    &__image {
        text-align: center;
        width: 100%;
        height: 10rem;

        img {
            max-width: 100%;
            max-height: 10rem;
        }
    }
    &__actions {
        padding: 1rem;
        text-align: center;
    }
    &:hover {
        transform: scale(1.04);
    }
}
</style>