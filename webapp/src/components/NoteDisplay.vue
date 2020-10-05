<template>
  <div>
    <h1>{{ note.title }}</h1>
    <div v-for="child in note.children" v-bind:key="child.id">
      <entry-display :entry="child"></entry-display>
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
        note: {
          id: 1,
          title: 'Note Header',
          children: [
            {
              id: 1,
              content: 'Hello World',
              children: [{
                id: 2,
                content: 'Child of 1 **strong**',
                focused: true,
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
    }
  }
</script>

<style scoped>

</style>
