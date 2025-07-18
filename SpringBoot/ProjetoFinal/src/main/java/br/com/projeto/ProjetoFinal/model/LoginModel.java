package br.com.projeto.ProjetoFinal.model;

import jakarta.persistence.Column;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;

public class LoginModel {

    @Email
    @NotBlank(message = "O email é obrigatório")
    @Column(name = "Email", length = 100, nullable = false)
    private String email;

    @NotBlank(message = "A senha é obrigatória")
    @Column(name = "Senha", columnDefinition = "TEXT", nullable = false)
    private String senha;

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getSenha() {
		return senha;
	}

	public void setSenha(String senha) {
		this.senha = senha;
	}

    
}
