export const parseJwt = () => {
    // Define a variável base64 que recebe o payload do usuário logado codificado
    let base64 = localStorage.getItem('usuario-login').split('.')[1];

    // Decodifica a base64 para string, através do método a to b
    // e converte a string para JSON
    return JSON.parse(window.atob(base64));
}