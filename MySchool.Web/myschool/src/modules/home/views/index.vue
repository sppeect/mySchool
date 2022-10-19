<template>
  <div class="home">
    <Modal :style="creating == false ? 'display:none' : 'display:block'" @closeModal="creating = false"></Modal>
    <Headers :name="name" :role="role" />

    <Navbars @selectPage="getPage" />
    <template v-if="this.page == 1">
      <div class="content">
        <h2>Dashboard</h2>
      </div>
    </template>

    <template v-if="this.page == 2">
      <div class="content">
        <div class="school">
          <div class="heading">
            <h2>Escolas</h2>
            <button @click="creating = true">Adicionar</button>
          </div>
        </div>

      </div>
    </template>
  </div>
</template>

<script>
import Headers from '../../shared/views/header.vue'
import Navbars from '../../shared/views/navbar.vue'
import Modal from '../components/modal.vue'

export default {
  name: 'home',
  components: { Headers, Navbars, Modal },
  data() {
    return {
      name: 'João Marcelo',
      role: 'Teacher',
      page: 2,
      creating:false,
    }
  },
  methods: {
    getPage(value) {
      return this.page = value;
    }
  }
}
</script>
