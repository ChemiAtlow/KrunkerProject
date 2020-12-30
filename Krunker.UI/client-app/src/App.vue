<template>
    <navigation />
    <div class="page">
        <router-view />
    </div>
    <toast
        v-if="msgState.toastMsg"
        :msg="msgState.toastMsg"
        @close="clearToast"
    />
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { messagesService } from "@/services";
import Navigation from "@/components/Navigation/index.vue";
import Toast from "@/components/Toast/index.vue";

const component = defineComponent({
    name: "App",
    components: { Navigation, Toast },
    setup() {
        const clearToast = () => messagesService.clearToast();
        return { msgState: messagesService.state, clearToast };
    }
});
export default component;
</script>

<style lang="scss">
* {
    box-sizing: border-box;
}
::-webkit-scrollbar {
    width: 0.4rem;
    &-track {
        background: $secondary;
    }
    &-thumb {
        background: $primary;
        &:hover {
            background: $primaryLight;
        }
    }
}
html,
body {
    height: 100%;
    overflow: hidden;
    margin: 0;
    padding: 0;
    background: $grayBg;
}
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: $dark;
    height: 100%;
    overflow: hidden;
    display: grid;
    grid-template-rows: $barHeight 1fr;
    .page {
        overflow-y: auto;
        position: relative;
    }
}
</style>
