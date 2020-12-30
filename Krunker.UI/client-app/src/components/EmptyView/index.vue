<template>
    <div class="empty-view">
        <div class="empty-view__circle">
            <div class="empty-view__circle-icon">
                <icons name="empty" />
            </div>
            <h2 class="empty-view__circle-text">Nothing to show!</h2>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Icons from "@/components/Icons/index.vue";

export default defineComponent({
    name: "EmptyView",
    components: { Icons }
});
</script>

<style lang="scss" scoped>
.empty-view {
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    &__circle {
        width: 70vmin;
        height: 70vmin;
        margin: 0 auto;
        display: flex;
        flex-direction: column;
        justify-content: center;
        max-width: 35rem;
        background: $lightGray;
        border-radius: 50%;
        box-shadow: 0 0 0.8rem $shadowGray;
        padding: 2.5rem;
        &-icon {
            height: 30vmin;
            fill: $primary;
        }
        &-text {
            color: $primary;
            margin: 0;
            font-size: 1.8rem;
            font-weight: bold;
            line-height: 40px;
            text-shadow: 0 0 0.2rem $light;
        }
    }
}
</style>