// Esperar a que el DOM esté completamente cargado
document.addEventListener('DOMContentLoaded', function () {

    // Theme Management
    const themeToggle = document.getElementById('themeToggle');
    const themeModalElement = document.getElementById('themeModal');
    const themeOptions = document.querySelectorAll('.theme-option');

    // Verificar que los elementos existen antes de continuar
    if (!themeToggle || !themeModalElement) {
        console.warn('Theme elements not found');
        return;
    }

    const themeModal = new bootstrap.Modal(themeModalElement);

    // Load saved theme - SOLO actualiza la UI, el tema ya está aplicado
    function loadTheme() {
        const savedTheme = localStorage.getItem('theme') || 'default';
        // El tema ya está aplicado por el script inline, solo actualizamos la UI
        updateActiveTheme(savedTheme);
        console.log('Theme UI updated:', savedTheme);
    }

    // Save theme to localStorage
    function saveTheme(theme) {
        localStorage.setItem('theme', theme);
        document.body.setAttribute('data-theme', theme);
        updateActiveTheme(theme);
        console.log('Theme saved:', theme);
    }

    // Update active theme indicator
    function updateActiveTheme(theme) {
        themeOptions.forEach(option => {
            if (option.getAttribute('data-theme') === theme) {
                option.classList.add('active');
            } else {
                option.classList.remove('active');
            }
        });
    }

    // Theme toggle button click
    themeToggle.addEventListener('click', function (e) {
        e.preventDefault();
        themeModal.show();
    });

    // Theme option selection
    themeOptions.forEach(option => {
        option.addEventListener('click', function () {
            const selectedTheme = this.getAttribute('data-theme');
            saveTheme(selectedTheme);

            // Show success message
            showToast('Tema actualizado', 'El tema se ha cambiado correctamente.');

            // Close modal after selection
            setTimeout(() => {
                themeModal.hide();
            }, 500);
        });
    });

    // Function to show toast notification
    function showToast(title, message) {
        // Remove existing toasts
        const existingToasts = document.querySelectorAll('.custom-toast-container');
        existingToasts.forEach(toast => toast.remove());

        const toastContainer = document.createElement('div');
        toastContainer.className = 'custom-toast-container position-fixed bottom-0 end-0 p-3';
        toastContainer.style.zIndex = '9999';
        toastContainer.innerHTML = `
            <div class="toast show" role="alert" aria-live="assertive" aria-atomic="true">
                <div class="toast-header">
                    <i class="bi bi-check-circle-fill text-success me-2"></i>
                    <strong class="me-auto">${title}</strong>
                    <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                </div>
                <div class="toast-body">
                    ${message}
                </div>
            </div>
        `;
        document.body.appendChild(toastContainer);

        // Auto remove after 3 seconds
        setTimeout(() => {
            toastContainer.remove();
        }, 3000);

        // Close button functionality
        const closeBtn = toastContainer.querySelector('.btn-close');
        if (closeBtn) {
            closeBtn.addEventListener('click', () => {
                toastContainer.remove();
            });
        }
    }

    // Load theme on page load
    loadTheme();

    // Smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const href = this.getAttribute('href');
            if (href === '#' || href === '') return;

            e.preventDefault();
            const target = document.querySelector(href);
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Chat button functionality
    // Chat button functionality - WhatsApp Integration
    const chatButton = document.getElementById('chatButton');
    if (chatButton) {
        chatButton.addEventListener('click', function () {
            // Tu número de WhatsApp con código de país (sin +, espacios ni guiones)
            // Ejemplo: México = 52, España = 34, Colombia = 57
            const phoneNumber = '526878786642'; 

            // Mensaje predeterminado
            const message = '¡Hola! Tengo una consulta sobre FacturaFacil.net';

            // Abrir WhatsApp
            const whatsappUrl = `https://wa.me/${phoneNumber}?text=${encodeURIComponent(message)}`;
            window.open(whatsappUrl, '_blank');
        });
    }

    // Navbar scroll effect
    window.addEventListener('scroll', function () {
        const navbar = document.querySelector('.navbar');
        if (navbar) {
            if (window.scrollY > 50) {
                navbar.style.boxShadow = '0 4px 20px rgba(0,0,0,0.2)';
            } else {
                navbar.style.boxShadow = '0 2px 10px rgba(0,0,0,0.1)';
            }
        }
    });

});