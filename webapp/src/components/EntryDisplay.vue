<template>
  <div>
    {{ entry.content }}
    <div style="padding-left: 15px">
      <entry-display v-for="child in entry.children" v-bind:key="child.id" :entry="child"></entry-display>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'EntryDisplay',
    props: {
      entry: Object
    }
  }
</script>

<style scoped>

</style>
