<template>
  <div>
    <Headers :name="name" :role="role"/>
    <Navbars/>
  </div>
</template>

<script>
import Headers from '../../shared/views/header.vue'
import Navbars from '../../shared/views/navbar.vue'
export default {
  name: 'home',
  components: { Headers, Navbars },
  data () {
    return {
      name: 'João Marcelo',
      role: 'Teacher'
    }
  }
}
</script>
