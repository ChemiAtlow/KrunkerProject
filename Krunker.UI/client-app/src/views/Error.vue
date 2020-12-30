<template>
    <div class="err-page">
        <h1 class="title">Oops!</h1>
        <p class="sub-title">404 - Page not found!</p>
        <span class="text">
            The page you are looking for might have been removed,
            <br />
            had its name changed or it is temporarily unavailable.
        </span>
    </div>
</template>

<style lang="scss" scoped>
.err-page {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    height: 100%;
    .title {
        font-size: 25vw;
        margin-top: 0;
        margin-bottom: 0.5rem;
    }
    .sub-title {
        font-size: 2rem;
        font-weight: bold;
        margin: 0.4rem 0;
    }
    .text {
        font-size: 1rem;
        margin: 0;
    }
}
</style>
