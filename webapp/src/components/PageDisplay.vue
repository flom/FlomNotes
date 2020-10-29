<template>
  <div class="container">
    <h1>{{ page.title }} {{ numOfChildren }}</h1>
    <button class="button" @click="printOut()">debug</button>
    <div v-for="child in page.children" v-bind:key="child.id">
      <entry-display :entry="child" @entry-focused="entryFocused($event)"></entry-display>
    </div>
  </div>
</template>

<script>
import EntryDisplay from './EntryDisplay';
import store from '../store/pages';

export default {
  name: 'PageDisplay',
  store,
  components: {
    EntryDisplay
  },
  data() {
    return {
      page: this.$store.state.page
    }
  },
  methods: {
    entryFocused(sourceEntryId) {
      this.page.children.forEach((child) => {
        this.setEntryFocus(child, sourceEntryId);
      })
    },
    setEntryFocus(entry, focusedEntryId) {
      entry.focused = entry.id === focusedEntryId;
      entry.children.forEach((child) => {
        this.setEntryFocus(child, focusedEntryId);
      });
    },
    printOut() {
      console.log('store state', this.$store.state.page);
    }
  },
  computed: {
    numOfChildren() {
      return this.$store.getters.numOfChildren;
    }
  }
}
</script>

<style scoped>
.container {
  max-width: 90ch;
  margin-left: auto;
  margin-right: auto
}
</style>
