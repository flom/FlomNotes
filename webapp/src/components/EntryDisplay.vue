<template>
  <div>
    <textarea v-if="entry.focused" v-model="content"></textarea>
    <div v-if="!entry.focused" v-html="renderedContent"></div>
    <div style="padding-left: 15px">
      <entry-display v-for="child in entry.children" v-bind:key="child.id" :entry="child"></entry-display>
    </div>
  </div>
</template>

<script>
import * as marked from 'marked';

export default {
  name: 'EntryDisplay',
  props: {
    entry: Object
  },
  data() {
    return {
      content: this.entry.content
    }
  },
  computed: {
    renderedContent() {
      return marked(this.content);
    }
  }
}
</script>

<style scoped>

</style>
