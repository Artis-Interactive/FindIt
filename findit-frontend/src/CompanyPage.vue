<template>
  <div>
    <Header>
      <AppHeader />
    </Header>
  </div>
</template>
  
<script>
import AppHeader from './components/AppHeader.vue'
export default {
    name: 'CompanyPage',
    components: {
      AppHeader
    }
  }
</script>

<style>
    html, body {
        margin: 0;
        padding: 0;
        width: 100%;
        height: 100%;
    }
</style>