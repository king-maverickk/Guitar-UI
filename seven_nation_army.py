import pygame
import pygame.mixer
import sys

# Initialize Pygame and Pygame Mixer
pygame.mixer.init()
pygame.mixer.set_num_channels(32)

# Load sounds
sounds = {
    'A_2': pygame.mixer.Sound('C:/Users/mogun/source/repos/Guitar-UI/sounds/A_2nd.WAV'),
    'A_3': pygame.mixer.Sound('C:/Users/mogun/source/repos/Guitar-UI/sounds/A_3rd.WAV'),
    'A_5': pygame.mixer.Sound('C:/Users/mogun/source/repos/Guitar-UI/sounds/A_5th.WAV'),
    'A_7': pygame.mixer.Sound('C:/Users/mogun/source/repos/Guitar-UI/sounds/A_7th.WAV'),
    'A_10': pygame.mixer.Sound('C:/Users/mogun/source/repos/Guitar-UI/sounds/A_10th.WAV')
}

# Dictionary to map keys to sounds
key_mapping = {
    pygame.K_q: 'A_2',
    pygame.K_1: 'A_3',
    pygame.K_2: 'A_5',
    pygame.K_3: 'A_7',
    pygame.K_4: 'A_10'
}

# Function to run the program
def main():
    clock = pygame.time.Clock()
    
    while True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                sys.exit()
            
            if event.type == pygame.KEYDOWN:
                if event.key in key_mapping:
                    sound_name = key_mapping[event.key]
                    sounds[sound_name].play()  # Play the sound when the key is pressed
        
        # We use a clock to control the frame rate even though no window is displayed
        clock.tick(60)

if __name__ == "__main__":
    # Run the main program without initializing a window
    pygame.display.set_mode((1, 1))  # Create a minimal window that won't show up
    main()
