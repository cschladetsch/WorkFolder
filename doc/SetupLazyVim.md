# Setup Lazy Vim

```bash

#!/bin/bash

# Function to clean up previous installations
cleanup() {
    sudo apt remove -y nodejs npm neovim
    sudo apt autoremove -y
    rm -rf ~/.config/nvim ~/.local/share/nvim ~/.nvm
    rm -f ~/.npmrc
}

# Function to install nvm
install_nvm() {
    curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.3/install.sh | bash
    export NVM_DIR="$HOME/.nvm"
    [ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh"
    [ -s "$NVM_DIR/bash_completion" ] && \. "$NVM_DIR/bash_completion"
}

# Function to install Node.js and npm using nvm
install_node() {
    nvm install 18
    nvm use 18
    nvm alias default 18
}

# Function to install the latest Neovim directly from GitHub releases
install_neovim() {
    sudo apt update
    sudo apt install -y wget

    # Download and install the latest Neovim release
    wget https://github.com/neovim/neovim/releases/download/stable/nvim.appimage -O nvim.appimage
    chmod u+x nvim.appimage
    sudo mv nvim.appimage /usr/local/bin/nvim
    sudo ln -sf /usr/local/bin/nvim /usr/bin/nvim
}

# Function to install LazyVim
install_lazyvim() {
    sudo apt install -y git

    # Clone the LazyVim starter template repository
    git clone https://github.com/LazyVim/starter ~/.config/nvim

    # Install Packer.nvim
    git clone --depth 1 https://github.com/wbthomason/packer.nvim\
      ~/.local/share/nvim/site/pack/packer/start/packer.nvim

    # Ensure the init.lua file is set up to load packer
    echo 'require("packer").startup(function(use)
        use "wbthomason/packer.nvim"
        -- Add additional plugins here
    end)' > ~/.config/nvim/init.lua

    # Run Neovim to set up the LazyVim configuration and install plugins
    nvim --headless -c 'autocmd User PackerComplete quitall' -c 'PackerSync'

    # Optional: Install language servers
    npm install -g typescript-language-server pyright

    echo "LazyVim installation complete!"
}

cleanup
install_nvm
install_node
install_neovim
install_lazyvim

```

Run that.

## Nvim config

```lua
-- ~/.config/nvim/init.lua

-- Bootstrap Packer
local fn = vim.fn
local install_path = fn.stdpath('data')..'/site/pack/packer/start/packer.nvim'
if fn.empty(fn.glob(install_path)) > 0 then
  fn.system({'git', 'clone', '--depth', '1', 'https://github.com/wbthomason/packer.nvim', install_path})
  vim.cmd [[packadd packer.nvim]]
end

-- Use LazyVim configuration
require('config.lazy')

```
