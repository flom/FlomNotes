<template>
  <div class="container">
    <h1>{{ page.title }}</h1>
    <button class="button" @click="printOut()">debug</button>
    <div v-for="child in page.children" v-bind:key="child.id">
      <entry-display :entry="child" @entry-focused="entryFocused($event)"></entry-display>
    </div>
  </div>
</template>

<script>
import EntryDisplay from './EntryDisplay';

export default {
  name: 'PageDisplay',
  components: {
    EntryDisplay
  },
  data() {
    return {
      page: {
        id: 1,
        title: 'Page Header',
        children: [
          {
            id: 1,
            content: 'Hello World',
            children: [{
              id: 2,
              content: 'Child of 1 **strong**',
              children: [{
                id: 3,
                content: 'Sub-Child of 2 **strong too**',
                children: []
              }, {
                id: 4,
                content: 'Another sub-Child of 2 _italic_\n\nnewline',
                children: []
              }]
            }]
          },
          {
            id: 5,
            content: 'Second Entry',
            children: []
          }
        ]
      }
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
      console.log(this.page);
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
