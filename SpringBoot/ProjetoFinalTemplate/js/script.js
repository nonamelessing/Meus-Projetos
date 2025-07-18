document.addEventListener('DOMContentLoaded', () => {
  const showLoginBtn = document.getElementById('showLogin');
  const showRegisterBtn = document.getElementById('showRegister');
  const loginSection = document.getElementById('login');
  const registerSection = document.getElementById('register');

  const formLogin = document.getElementById('formLogin');
  const formRegister = document.getElementById('formRegister');
  const loginMessage = document.getElementById('loginMessage');
  const registerMessage = document.getElementById('registerMessage');

  showLoginBtn.addEventListener('click', () => {
    loginSection.classList.remove('hidden');
    registerSection.classList.add('hidden');
    showLoginBtn.setAttribute('aria-expanded', 'true');
    showRegisterBtn.setAttribute('aria-expanded', 'false');
    clearMessages();
  });

  showRegisterBtn.addEventListener('click', () => {
    registerSection.classList.remove('hidden');
    loginSection.classList.add('hidden');
    showLoginBtn.setAttribute('aria-expanded', 'false');
    showRegisterBtn.setAttribute('aria-expanded', 'true');
    clearMessages();
  });

  function clearMessages() {
    loginMessage.textContent = '';
    loginMessage.className = 'message';
    registerMessage.textContent = '';
    registerMessage.className = 'message';
  }

  formRegister.addEventListener('submit', async (e) => {
    e.preventDefault();
    registerMessage.textContent = '';
    registerMessage.className = 'message';

    const nome = formRegister.nome.value.trim();
    const email = formRegister.email.value.trim().toLowerCase();
    const senha = formRegister.senha.value;
    const telefone = formRegister.telefone.value.trim();

    if (!nome || !email || !senha || !telefone) {
      registerMessage.textContent = 'Por favor, preencha todos os campos.';
      registerMessage.classList.add('error');
      return;
    }

    try {
      const response = await fetch('http://localhost:8080/usuarios', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nome, email, senha, telefone })
      });

      if (response.ok) {
        registerMessage.textContent = 'Cadastro realizado com sucesso!';
        registerMessage.classList.add('success');
        formRegister.reset();
      } else if (response.status === 409) {
        registerMessage.textContent = 'Este e-mail já está cadastrado.';
        registerMessage.classList.add('error');
      } else {
        registerMessage.textContent = 'Erro ao realizar cadastro. Tente novamente.';
        registerMessage.classList.add('error');
      }
    } catch (error) {
      registerMessage.textContent = 'Erro de conexão. Verifique sua internet.';
      registerMessage.classList.add('error');
      console.error(error);
    }
  });
  
  formLogin.addEventListener('submit', async (e) => {
    e.preventDefault();
    loginMessage.textContent = '';
    loginMessage.className = 'message';

    const email = formLogin.email.value.trim().toLowerCase();
    const senha = formLogin.senha.value;

    if (!email || !senha) {
      loginMessage.textContent = 'Por favor, preencha todos os campos.';
      loginMessage.classList.add('error');
      return;
    }

    try {
      const response = await fetch('http://localhost:8080/usuarios/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, senha })
      });

      if (response.ok) {
        loginMessage.textContent = 'Login realizado com sucesso!';
        loginMessage.classList.add('success');
        formLogin.reset();
        
      } else if (response.status === 401) {
        loginMessage.textContent = 'Email ou senha inválidos.';
        loginMessage.classList.add('error');
      } else {
        loginMessage.textContent = 'Erro ao entrar. Tente novamente.';
        loginMessage.classList.add('error');
      }
    } catch (error) {
      loginMessage.textContent = 'Erro de conexão. Verifique sua internet.';
      loginMessage.classList.add('error');
      console.error(error);
    }
  });

  showLoginBtn.click();
});
