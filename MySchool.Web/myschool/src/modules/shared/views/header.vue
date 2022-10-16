<template>
    <div class="header">
      <div>
          <span class="userInfo">
              <p>{{name}}</p>
              <p>{{role}}</p>
          </span>
          <img class="icon" src="../../../assets/imgs/perfil.svg"/>
      </div>
    </div>
  </template>

<script>
export default {
  name: 'header',
  props: {
    name: { type: String },
    role: { type: String }
  }
}
</script>

  <style>

  </style>
