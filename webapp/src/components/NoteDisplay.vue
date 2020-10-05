<template>
  <div style="border: 1px solid black;">
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
    name: 'NoteDisplay',
    components: {
      EntryDisplay
    },
    data() {
      return {
        page: {
          id: 1,
          title: 'Note Header',
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
                }]
              }]
            },
            {
              id: 4,
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

</style>
