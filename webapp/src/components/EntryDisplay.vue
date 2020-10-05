<template>
  <div>
    <textarea v-if="entry.focused" v-model="this.currentEntry.content"></textarea>
    <div v-if="!entry.focused" v-html="renderedContent" @click="editContent()"></div>
    <div style="padding-left: 15px">
      <entry-display v-for="child in entry.children" v-bind:key="child.id" :entry="child" @unfocus="unfocus($event)"></entry-display>
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
      currentEntry: this.entry
    }
  },
  computed: {
    renderedContent() {
      return marked(this.currentEntry.content);
    }
  },
  methods: {
    editContent() {
      this.currentEntry.focused = true;
      this.$emit('unfocus', this.currentEntry.id);
    },
    unfocus(sourceEntryId) {
      this.$emit('unfocus', sourceEntryId);
    }
  }
}
</script>

<style scoped>

</style>
