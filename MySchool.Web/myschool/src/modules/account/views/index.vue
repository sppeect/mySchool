<template>
    <div class="container-fluid">
        <div class="row">
            <div class="form">
                <h3 class="title">Login</h3>
                <div class="email">
                    <label for="email">Email</label>
                    <input type="text" class="form-control " name="email" v-model="email"
                        placeholder="meuemail@email.com">
                </div>
                <div class="password">
                    <label for="password">Password</label>
                    <input type="password" class="form-control " name="password" v-model="password"
                        placeholder="*************">
                </div>
                <button class="btn btn-primary" type="button" @click="signUp">Login</button>
            </div>
        </div>
    </div>
</template>

<script>
import { mapActions } from 'vuex'
/* eslint-disable */
export default {
    name: "login",
    data() {
        return {
            email: "",
            password: "",
            username: "",
            submitted: false,
            hello: "Olá Mundo!!"
        };
    },
    methods: {
        ...mapActions({
            signIn: "auth/signIn",
        }),
        signUp() {
            this.submitted = true;
            let login = { email: this.email, password: this.password }
            this.signIn(login).then((resp) => {
                if (resp.data) {
                    this.password = "";
                    this.$router.push("/success");
                }
            });
        },
    }
}
</script>

<style>

</style>